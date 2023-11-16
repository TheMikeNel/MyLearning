using System;

namespace Mod6_Company
{
    struct Worker
    {
        public int ID { get; set; }

        public DateTime DateOfAdd { get; set; }
        
        public string FIO { get; set; }

        public byte Age { get; set; }

        public byte Height { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public Worker (string fio, byte age, byte height, DateTime dateOfBirth, string placeOfBirth)
        {
            ID = 0;
            DateOfAdd = DateTime.Now;
            FIO = fio;
            Age = age;
            Height = height;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
        }

        /// <summary>
        /// Получить параметры работника в виде строки с разделителем '#'
        /// </summary>
        /// <returns></returns>
        public string GetWorkerParamsAsString() => $"{ID}#{DateOfAdd}#{FIO}#{Age}#{Height}#{DateOfBirth.ToShortDateString()}#{PlaceOfBirth}";

        /// <summary>
        /// Установить параметры работника, заданные как строка с разделителем '#'
        /// </summary>
        /// <param name="line"></param>
        public void SetWorkerByLine(string line)
        {
            string[] s;
            s = line.Split('#');
            ID = int.Parse(s[0]);
            DateOfAdd = DateTime.Parse(s[1]);
            FIO = s[2];
            Age = byte.Parse(s[3]);
            Height = byte.Parse(s[4]);
            DateOfBirth = DateTime.Parse(s[5]);
            PlaceOfBirth = s[6];
        }

    }
}
