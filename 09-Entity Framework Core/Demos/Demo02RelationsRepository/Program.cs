﻿using Demo02RelationsRepository.Data;
using Demo02RelationsRepository.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

var blogs = context.Blogs.ToList();

blogs.ForEach(b => Console.WriteLine($"{b.Nom} combien de posts : {b.Posts.Count}"));


// Initialement, lorsque l'on charge les blogs depuis la db, les posts et les tags ne sont pas chargés
// On utilise le lazy loading pour économiser la mémoire et optimiser le programme

blogs = context.Blogs.Include(b => b.Posts).ToList();

blogs.ForEach(b => Console.WriteLine($"{b.Nom} combien de posts : {b.Posts.Count}"));

blogs.FirstOrDefault()?.Posts.ToList().ForEach(p => Console.WriteLine(p.Titre));

// /!\ pour l'inverse, le include ne sera pas nécessaire
Console.WriteLine(context.Posts.FirstOrDefault()?.Blog.Nom);


//var head = new BlogHeader
//{
//    Content = "Bienvenue sur le blog de JOHNNY",
//    BlogId = 1
//};

//context.BlogHeaders.Add(head);
//context.Add(head);
//context.Set<BlogHeader>().Add(head);

//context.SaveChanges();

Console.WriteLine(context.Blogs.FirstOrDefault()?.Header?.Content);



//context.Tags.Add(new Tag() { Name = "Rouge" });
//context.Tags.Add(new Tag() { Name = "Information" });
//context.Tags.Add(new Tag() { Name = "Chanteur" });
//context.Tags.Add(new Tag() { Name = "Humour" });
//context.SaveChanges();


//context.BlogTags.Add(new BlogTag { BlogId = 1, TagId = 3 });
//context.BlogTags.Add(new BlogTag { BlogId = 3, TagId = 4 });
//context.BlogTags.Add(new BlogTag { BlogId = 1, TagId = 1 });
//context.BlogTags.Add(new BlogTag { BlogId = 3, TagId = 1 });

//context.SaveChanges();

context.Tags
       .Include(t => t.BlogTags)
       //.ThenInclude(bt => bt.Blog)
       //.Where(t => t.Name == "Rouge")
       .ToList()
       .ForEach(t =>
       {
           Console.WriteLine("\nNom du tag " + t.Name);
           Console.WriteLine("Blogs :");
           t.BlogTags.ForEach(bt => Console.WriteLine(" - " + bt.Blog.Nom));
       });