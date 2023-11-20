﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Mod8_Collections
{
    internal class WriteBook
    {
        static string xmlPath = "Notes.xml";
        static XElement writeBook = new XElement("WRITEBOOK");

        public static void WriteBookWorking()
        {
            List<Note> notes = new List<Note>();

            Console.WriteLine("<<< Записная Книга >>>");
            char key = 'a';

            while (key != 'q')
            {
                Console.Write("\n== Добавление записи ==");
                Console.Write("\nВведите ФИО: "); string fio = Console.ReadLine();
                Console.Write("\nУлица: "); string street = Console.ReadLine();
                Console.Write("\nНомер дома: "); string houseNum = Console.ReadLine();
                Console.Write("\nНомер квартиры: "); string flatNum = Console.ReadLine();
                Console.Write("\nМобильный телефон: "); string mobilePhone = Console.ReadLine();
                Console.Write("\nДомашний телефон: "); string homePhone = Console.ReadLine();

                Note note = new Note(fio, street, houseNum, flatNum, mobilePhone, homePhone);
                notes.Add(note);
                Console.WriteLine(note.FIO);
                Console.WriteLine("\n>>> Запись добавлена <<<");

                Console.WriteLine("\nДля продолжения, нажмите любую клавишу. Для добавления записей в книгу и выхода, нажмите \"q\"");
                key = char.ToLower(Console.ReadKey(true).KeyChar);
            }
            Console.WriteLine("Записи внесены в книгу.");
            SerializeNotes(notes);
        }

        static void SerializeNotes(List<Note> notes)
        {
            XElement person = new XElement("PERSON");
            XElement address = new XElement("ADDRESS");
           
            XElement phones = new XElement("PHONES");

            XAttribute fio = new XAttribute("FIO", "");

            XAttribute street = new XAttribute("Street", "");
            XAttribute houseNum = new XAttribute("HouseNumber", "");
            XAttribute flatNum = new XAttribute("FlatNumber", "");

            XAttribute mobilePhone = new XAttribute("MobilePhone", "");
            XAttribute homePhone = new XAttribute("HomePhone", "");

            foreach (Note note in notes)
            {
                person.Add(fio.Value = note.FIO);

                address.Add(street.Value = note.Street);
                address.Add(houseNum.Value = note.HouseNumber);
                address.Add(flatNum.Value = note.FlatNumber);

                person.Add(address);

                phones.Add(mobilePhone.Value = note.MobilePhone);
                phones.Add(homePhone.Value = note.HomePhone);

                person.Add(phones);

                writeBook.Add(person);
            }

            writeBook.Save(xmlPath);
        }

        //static void AddNotes(List<Note> notes)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));

        //    Stream serializeStream = new FileStream(xmlPath, FileMode.OpenOrCreate, FileAccess.Write, );

        //    serializer.Serialize(serializeStream, notes);

        //    serializeStream.Close();
        //}
    }
}
