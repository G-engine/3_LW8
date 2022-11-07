using System.Xml.Serialization;
using System.IO.Compression;
using System.Text;
using library;

Animal animal = new Animal("Russia", "Bob", "Bear", false);

//serialize xml
XmlSerializer writer = new XmlSerializer(typeof(Animal));
Directory.CreateDirectory("serialization");
FileStream writeFile = File.Create("serialization/Serialization.xml");
writer.Serialize(writeFile, animal);  
writeFile.Close();  

//deserialize xml
XmlSerializer reader = new XmlSerializer(typeof(Animal));
FileStream readFile = File.OpenRead("serialization/Serialization.xml");
Animal animalRead = (Animal)reader.Deserialize(readFile);
readFile.Close();

Console.WriteLine($"{animalRead.Country}, {animalRead.WhatAnimal} {animalRead.Name}, " +
                  $"Hiding: {animalRead.HideFromOtherAnimals}");
                  
//find and read file
string[] foundFiles = Directory.GetFiles("D:/projects/C#/lw8/lw8/", "Serialization.xml", SearchOption.AllDirectories);
FileStream file = File.OpenRead(foundFiles[0]);
byte[] buffer = new byte[file.Length];
file.Read(buffer, 0, buffer.Length);
file.Close();

Console.WriteLine();
Console.WriteLine(Encoding.Default.GetString(buffer));

//compression
ZipFile.CreateFromDirectory("serialization/", "zipFile.zip");