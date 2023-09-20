namespace DatabaseConnectivity
{
    public class RegionUI
    {
        // Cetak hasil All Region
        public static void AllRegion(Region region)
        {
            var getAllRegion = region.GetAll();

            if (getAllRegion.Count > 0)
            {
                foreach (var reg in getAllRegion)
                {
                    Console.WriteLine($"Id: {reg.Id}, Name: {reg.Name}");
                }
            }
            else
            {
                Console.WriteLine("No data found");
            }
        }

        // Cetak hasil Region by Id
        public static void RegionById(Region region, int id)
        {
            var getRegionById = region.GetById(id);
            if (getRegionById != null)
            {
                Console.WriteLine("Hasil yang ditemukan : ");
                Console.WriteLine($"Id: {getRegionById.Id}, Name: {getRegionById.Name}");
            }
            else
                Console.WriteLine("Hasil tidak ditemukan");
            
        }

        // Cetak hasil Insert Region
        public static void InsertRegion(Region region)
        {
            var insertResult = region.Insert("New Region");
            int.TryParse(insertResult, out int result);
            if (result > 0)
            {
                Console.WriteLine("Insert Success");
            }
            else
            {
                Console.WriteLine("Insert Failed");
                Console.WriteLine(insertResult);
            }
        }

        // Cetak hasil Update Region
        public static void UpdateRegion(Region region, int id, string nama)
        {
            var updateResult = region.Update(id, nama);

            Console.WriteLine(updateResult);
        }

        // Cetak hasil Delete Region
        public static void DeleteRegion(Region region, int id)
        {
            var deleteResult = region.Delete(id);

            Console.WriteLine(deleteResult);
        }
    }
}