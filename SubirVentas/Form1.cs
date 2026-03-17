using Microsoft.EntityFrameworkCore;
using SubirVentas.Models;

namespace SubirVentas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static async Task AddRangeIfAnyAsync<T>(DbSet<T> set, List<T>? items) where T : class
        {
            if (items is { Count: > 0 })
                await set.AddRangeAsync(items);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Sincronizando...";
            button1.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            await SubirVentas();
            Cursor.Current = Cursors.Default;
            button1.Enabled = true;
            button1.Text = "Sincronizar";
        }

        private async Task SubirVentas()
        {
            try
            {
                var factory = new AppDbContextFactory();
                var location = Environment.GetEnvironmentVariable("location", EnvironmentVariableTarget.Machine);
                var mysqllocal = Environment.GetEnvironmentVariable("mysqllocal", EnvironmentVariableTarget.Machine);
                var mysqlremoto = Environment.GetEnvironmentVariable("mysqlremoto", EnvironmentVariableTarget.Machine);
                var mysqlremotoMatriz = Environment.GetEnvironmentVariable("mysqlremotomatriz", EnvironmentVariableTarget.Machine);

                await using var contextLocal = factory.CreateDbContext(new string[] { mysqllocal });
                await using var contextHosting = factory.CreateDbContext(new string[] { mysqlremoto });
                await using var contextHostingUpdate = factory.CreateDbContext(new string[] { mysqlremoto });
                await using var contextHostingMatriz = factory.CreateDbContext(new string[] { mysqlremotoMatriz });
                await ActualizaInventario(location, contextLocal, contextHostingMatriz, contextHosting);

                MessageBox.Show("Se sincronizó la información correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo sincronizar la información, revise su conexión de internet: " + e.Message);
            }
        }

        private static async Task ActualizaInventario(string? location, Models.AppContext contextLocal, Models.AppContext contextHosting, Models.AppContext contextHostingMatriz)
        {
            await contextLocal.PRODUCTS.ExecuteDeleteAsync();
            await contextLocal.CATEGORIES.ExecuteDeleteAsync();
            await contextLocal.PRODUCTS_CAT.ExecuteDeleteAsync();
            if (contextLocal.ChangeTracker.HasChanges())
                await contextLocal.SaveChangesAsync();

            var ProductsLocal = await contextLocal.PRODUCTS.AsNoTracking().ToListAsync();
            var ProductsHosting = await contextHosting.PRODUCTS.AsNoTracking().ToListAsync();
            var missingProducts = ProductsHosting.Except(ProductsLocal).ToList();

            var CategoriesLocal = await contextLocal.CATEGORIES.AsNoTracking().ToListAsync();
            var CategoriesHosting = await contextHosting.CATEGORIES.AsNoTracking().ToListAsync();
            var missingCategories = CategoriesHosting.Except(CategoriesLocal).ToList();

            var ProductsCatLocal = await contextLocal.PRODUCTS_CAT.AsNoTracking().ToListAsync();
            var ProductsCatHosting = await contextHosting.PRODUCTS_CAT.AsNoTracking().ToListAsync();
            var missingProductsCat = ProductsCatHosting.Except(ProductsCatLocal).ToList();

            await AddRangeIfAnyAsync(contextLocal.PRODUCTS, missingProducts);
            await AddRangeIfAnyAsync(contextLocal.CATEGORIES, missingCategories);
            await AddRangeIfAnyAsync(contextLocal.PRODUCTS_CAT, missingProductsCat);
            if (contextLocal.ChangeTracker.HasChanges())
                await contextLocal.SaveChangesAsync();

            foreach (var item in missingProducts)
            {
                var product = contextLocal.STOCKCURRENT.FirstOrDefault(x => x.PRODUCT == item.ID);
                if (product is null)
                    contextLocal.STOCKCURRENT.Add(new STOCKCURRENT { PRODUCT = item.ID, UNITS = 0, LOCATION = "0" });
            }
            if (contextLocal.ChangeTracker.HasChanges())
                await contextLocal.SaveChangesAsync();
            if (contextHosting.ChangeTracker.HasChanges())
                await contextHosting.SaveChangesAsync();
        }
    }
}
