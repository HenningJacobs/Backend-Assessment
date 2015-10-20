namespace MusicBackend.Migrations
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicBackend.Models.ArtistDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MusicBackend.Models.ArtistDBContext";
        }

        protected override void Seed(MusicBackend.Models.ArtistDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // ColumnFields.Clear();
            /*
            //Import data from excel
            string FileName = "\\Docs\\artists.xlsx";
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            string HDR = "HDR=NO;";
            //HDR += "NO";
            //HDR += ";";
            //if (eft == "Excel File 2003")
            MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + FileName + @"';Extended Properties=""Excel 12.0;" + HDR + @"""");
            //else
            //{
            //    String Constring = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FileName + ";" + "Extended Properties=Excel 8.0" + HDR;
            //    MyConnection = new System.Data.OleDb.OleDbConnection(Constring);
            //}
            MyConnection.Open();

            DataTable schemaTable = MyConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new Object[] { null, null, null, "TABLE" });
            String SheetName = "";
            foreach (DataRow dr in schemaTable.Rows)
            {
                SheetName = dr["TABLE_NAME"].ToString();
                break;
            }
            MyConnection.Close();

            try
            {
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + SheetName + "]", MyConnection);
                System.Data.DataSet DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
            }
            catch { }

            MyConnection.Close();
            */
            


        }
    }
}
