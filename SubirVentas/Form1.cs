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
                var mysqllocal = Environment.GetEnvironmentVariable("mysqllocal", EnvironmentVariableTarget.Machine);
                var mysqlremoto = Environment.GetEnvironmentVariable("mysqlremoto", EnvironmentVariableTarget.Machine);

                await using var contextLocal = factory.CreateDbContext(new string[] { mysqllocal });
                await using var contextHosting = factory.CreateDbContext(new string[] { mysqlremoto });
                await using var contextHostingUpdate = factory.CreateDbContext(new string[] { mysqlremoto });

                var CustomersLocal = await contextLocal.CUSTOMERS.AsNoTracking().ToListAsync();
                var CustomersHosting = await contextHosting.CUSTOMERS.AsNoTracking().ToListAsync();
                var missingCustomers = CustomersLocal.Except(CustomersHosting).ToList();

                var CategoriesLocal = await contextLocal.CATEGORIES.AsNoTracking().ToListAsync();
                var CategoriesHosting = await contextHosting.CATEGORIES.AsNoTracking().ToListAsync();
                var missingCategories = CategoriesLocal.Except(CategoriesHosting).ToList();

                var ProductsLocal = await contextLocal.PRODUCTS.AsNoTracking().ToListAsync();
                var ProductsHosting = await contextHosting.PRODUCTS.AsNoTracking().ToListAsync();
                var missingProducts = ProductsLocal.Except(ProductsHosting).ToList();

                var ProductsCatLocal = await contextLocal.PRODUCTS_CAT.AsNoTracking().ToListAsync();
                var ProductsCatHosting = await contextHosting.PRODUCTS_CAT.AsNoTracking().ToListAsync();
                var missingProductsCat = ProductsCatLocal.Except(ProductsCatHosting).ToList();

                var StockCurrentLocal = await contextLocal.STOCKCURRENT.AsNoTracking().ToListAsync();
                var StockCurrentHosting = await contextHosting.STOCKCURRENT.AsNoTracking().ToListAsync();
                var missingStockCurrent = StockCurrentLocal.Except(StockCurrentHosting).ToList();

                var StockDiaryLocal = await contextLocal.STOCKDIARY.AsNoTracking().ToListAsync();
                var StockDiaryHosting = await contextHosting.STOCKDIARY.AsNoTracking().ToListAsync();
                var missingStockDiary = StockDiaryLocal.Except(StockDiaryHosting).ToList();

                var ClosedCashLocal = await contextLocal.CLOSEDCASH.AsNoTracking().ToListAsync();
                var ClosedCashHosting = await contextHosting.CLOSEDCASH.AsNoTracking().ToListAsync();
                var missingClosedCash = ClosedCashLocal.Except(ClosedCashHosting).ToList();

                var PeopleLocal = await contextLocal.PEOPLE.AsNoTracking().ToListAsync();
                var PeopleHosting = await contextHosting.PEOPLE.AsNoTracking().ToListAsync();
                var missingPeople = PeopleLocal.Except(PeopleHosting).ToList();

                var RolesLocal = await contextLocal.ROLES.AsNoTracking().ToListAsync();
                var RolesHosting = await contextHosting.ROLES.AsNoTracking().ToListAsync();
                var missingRoles = RolesLocal.Except(RolesHosting).ToList();

                var LocationsLocal = await contextLocal.LOCATIONS.AsNoTracking().ToListAsync();
                var LocationsHosting = await contextHosting.LOCATIONS.AsNoTracking().ToListAsync();
                var missingLocations = LocationsLocal.Except(LocationsHosting).ToList();

                var PaymentsLocal = await contextLocal.PAYMENTS.AsNoTracking().ToListAsync();
                var PaymentsHosting = await contextHosting.PAYMENTS.AsNoTracking().ToListAsync();
                var missingPayments = PaymentsLocal.Except(PaymentsHosting).ToList();

                var ReceiptsLocal = await contextLocal.RECEIPTS.AsNoTracking().ToListAsync();
                var ReceiptsHosting = await contextHosting.RECEIPTS.AsNoTracking().ToListAsync();
                var missingReceipts = ReceiptsLocal.Except(ReceiptsHosting).ToList();

                var TicketlinesLocal = await contextLocal.TICKETLINES.AsNoTracking().ToListAsync();
                var TicketlinesHosting = await contextHosting.TICKETLINES.AsNoTracking().ToListAsync();
                var missingTicketlines = TicketlinesLocal.Except(TicketlinesHosting).ToList();

                var TicketsLocal = await contextLocal.TICKETS.AsNoTracking().ToListAsync();
                var TicketsHosting = await contextHosting.TICKETS.AsNoTracking().ToListAsync();
                var missingTickets = TicketsLocal.Except(TicketsHosting).ToList();

                await AddRangeIfAnyAsync(contextHosting.CUSTOMERS, missingCustomers);
                await AddRangeIfAnyAsync(contextHosting.CATEGORIES, missingCategories);
                await AddRangeIfAnyAsync(contextHosting.PRODUCTS, missingProducts);
                await AddRangeIfAnyAsync(contextHosting.PRODUCTS_CAT, missingProductsCat);
                await AddRangeIfAnyAsync(contextHosting.STOCKCURRENT, missingStockCurrent);
                await AddRangeIfAnyAsync(contextHosting.STOCKDIARY, missingStockDiary);
                await AddRangeIfAnyAsync(contextHosting.CLOSEDCASH, missingClosedCash);
                await AddRangeIfAnyAsync(contextHosting.PEOPLE, missingPeople);
                await AddRangeIfAnyAsync(contextHosting.ROLES, missingRoles);
                await AddRangeIfAnyAsync(contextHosting.LOCATIONS, missingLocations);
                await AddRangeIfAnyAsync(contextHosting.PAYMENTS, missingPayments);
                await AddRangeIfAnyAsync(contextHosting.RECEIPTS, missingReceipts);
                await AddRangeIfAnyAsync(contextHosting.TICKETLINES, missingTicketlines);
                await AddRangeIfAnyAsync(contextHosting.TICKETS, missingTickets);

                if (contextHosting.ChangeTracker.HasChanges())
                    await contextHosting.SaveChangesAsync();

                contextHostingUpdate.CUSTOMERS.UpdateRange(CustomersLocal);
                contextHostingUpdate.CATEGORIES.UpdateRange(CategoriesLocal);
                
                contextHostingUpdate.PRODUCTS.UpdateRange(ProductsLocal);
                contextHostingUpdate.PRODUCTS_CAT.UpdateRange(ProductsCatLocal);
                contextHostingUpdate.PEOPLE.UpdateRange(PeopleLocal);
                contextHostingUpdate.LOCATIONS.UpdateRange(LocationsLocal);
                contextHostingUpdate.ROLES.UpdateRange(RolesLocal);
                contextHostingUpdate.STOCKCURRENT.UpdateRange(StockCurrentLocal);
                contextHostingUpdate.STOCKDIARY.UpdateRange(StockDiaryLocal);
                contextHostingUpdate.APPLICATIONS.Update(new APPLICATIONS { ID = "openbravopos", FECHA = DateTime.Now });

                if (contextHostingUpdate.ChangeTracker.HasChanges())
                    await contextHostingUpdate.SaveChangesAsync();

                MessageBox.Show("Se sincronizó la información correctamente");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo sincronizar la información, revise su conexión de internet: " + e.Message);
            }
        }
    }
}
