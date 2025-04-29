var repository = new TaskRepository();
var taskService = new TaskService(repository);

while (true)
{
    Console.Clear();
    Console.WriteLine("Görev Takip Uygulaması");
    Console.WriteLine("1. Görev Ekle");
    Console.WriteLine("2. Görevleri Listele");
    Console.WriteLine("3. Görevi Tamamla");
    Console.WriteLine("0. Çıkış");
    Console.Write("Seçiminiz: ");

    string? secim = Console.ReadLine();
    Console.WriteLine();

    if (secim == "0")
    {
        break;
    }

    switch (secim)
    {
        case "1":
            Console.Write("Başlık: ");
            string? baslik = Console.ReadLine();
            Console.Write("Açıklama: ");
            string? aciklama = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(baslik) && !string.IsNullOrWhiteSpace(aciklama))
            {
                taskService.CreateTask(baslik, aciklama);
                Console.WriteLine("Görev eklendi.");
            }
            else
            {
                Console.WriteLine("Boş bilgi girilemez.");
            }
            break;

        case "2":
            var tasks = taskService.GetListTask();
            if (tasks.Count == 0)
            {
                Console.WriteLine("Henüz görev yok.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"[{(task.IsCompleted ? "X" : " ")}] {task.Title} - {task.Description} (ID: {task.TaskItemID})");
                }
            }
            break;

        case "3":
            Console.Write("Tamamlanacak Görevin ID'sini girin: ");
            string? idGirdi = Console.ReadLine();
            if (Guid.TryParse(idGirdi, out Guid id))
            {
                bool tamamlandi = taskService.CompleteTask(id);
                Console.WriteLine(tamamlandi ? "Görev tamamlandı." : "Görev bulunamadı.");
            }
            else
            {
                Console.WriteLine("Geçersiz ID formatı.");
            }
            break;

        default:
            Console.WriteLine("Geçersiz seçim.");
            break;
    }

    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
    Console.ReadKey();
}
