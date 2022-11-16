using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using GorgesMusic.Data.Models;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace GorgesMusic.Data.Seed;

public static class Seeder
{
    const string fileName = @"C:\Users\Georges\Desktop\19332_Spotify_Songs.csv";

    public static void SeedData(GorgesMusicDbContext dbContext)
    {
        if (dbContext.Songs.Any())
        {
            return;
        }

        List<CsvLine> lines = new List<CsvLine>();

        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            MissingFieldFound = null
        };
        try
        {
            using var fs = new StreamReader(fileName);
            // I just need this one line to load the records from the file in my List<CsvLine>
            using (var csv = new CsvReader(fs, configuration))
            {
                lines = csv.GetRecords<CsvLine>().ToList();
            }
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        lines = lines.Where(x => !string.IsNullOrWhiteSpace(x.AudioLink) && !string.IsNullOrWhiteSpace(x.ImageLink)
        && !string.IsNullOrWhiteSpace(x.Song)).ToList();

        //Parallel.For(1, 3000, (i, state) =>
        //{
        //    var song = new Song
        //    {
        //        Name = lines[i].Song,
        //        AudioLink = lines[i].AudioLink,
        //        CardImage = lines[i].ImageLink.Split(",")[3]
        //    };
        //    dbContext.Songs.Add(song);
        //    Console.WriteLine(song);

        //});

        for (int i = 1; i < 614; i++)
        {
            var song = new Song
            {
                Name = lines[i].Song,
                AudioLink = lines[i].AudioLink,
                CardImage = lines[i].ImageLink.Split(",")[3]
            };
            dbContext.Songs.Add(song);
            Console.WriteLine(song);
        }

       dbContext.SaveChanges();

    }

    //public static void SeedDataHandler(GorgesMusicDbContext dbContext, Cloudinary cloudinary)
    //{
    //    var uploadParams = new VideoUploadParams
    //    {
    //        File = new FileDescription(@"C:\Users\Georges\Downloads\Dragan_Kojic_KEBA_-_EVALA_(NEW_2022.).mp3"),
    //        UseFilename = true,
    //        UniqueFilename = false,
    //        Overwrite = true,
    //        Folder = "GorgesMusic",
    //        DisplayName = "Dragan Kojic KEBA - EVALA (NEW 2022.)"
    //    };

    //    var uploadResult = cloudinary.Upload(uploadParams);

    //    List<Song> songs = new List<Song>
    //   {
    //       new Song
    //       {
    //           Name = "Dragan Kojic KEBA - EVALA (NEW 2022.)",
    //           Genre = Genre.Balkan,
    //           AudioLink = uploadResult.Url.ToString()
    //       }
    //   };
    //    dbContext.Songs.AddRange(songs);
    //    dbContext.SaveChanges();
    //}
}