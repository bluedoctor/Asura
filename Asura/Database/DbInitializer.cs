﻿using System;
using System.Collections.Generic;
using System.Linq;
using Asura.Comm;
using Asura.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Asura.Database
{
    public static class DbInitializer
    {
        public static void Initialize(AsuraContext context)
        {
            context.Database.EnsureCreated();
            if(context.Articles.Any())
                return;
            var account = new Account()
            {
                Username = "admin",
                Address = "hahah",
                CreateTime = DateTime.Now,
                Email = "luodaoyi@gmail.com",
                LoginIp = "127.0.0.1",
                LoginTime = DateTime.Now,
                LogoutTime = DateTime.Now,
                Password = MD5Helper.MD5Hash("admin"),
                PhoneN = "13888888888",
                Token = string.Empty
            };
            context.Accounts.Add(account);
            context.SaveChanges();
            
            var blogger = new Blogger()
            {
                BlogName = "瞎几把写",
                BeiAn = "浙备 adadwawd",
                BTitle = "记事本",
                Copyright = "hahah",
                SubTitle = "1111",
                
            };
            context.Bloggers.Add(blogger);
            context.SaveChanges();
            
            var servi = new  Serie()
            {
                CreateTime = DateTime.Now,
                Desc = "做测试用啊",
                Name = "测试专题",
                Slug = "Test Servi",
            };
            context.Series.Add(servi);
            context.SaveChanges();
            
            var tag = new Tag()
            {
                TagName = "默认"
            };
            context.Tags.Add(tag);
            context.SaveChanges();
            
            for (var i = 0; i < 15; i++)
            {
                var tag1 = new Tag()
                {
                    TagName = $"默认{i}"
                };
                context.Tags.Add(tag1);
                
                context.SaveChanges();
                var article = new Article()
                {
                    Title = $"Hello World -【{i}】",
                    Slug = $"hello-world{i}",
                    Author = "luodaoyi",
                    Content = "# Hello World \n ## 你好世界！\n 如果你看到这条信息说明就好了",
                    Count = 10,
                    CreateTime = DateTime.Now,
                    DeleteTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    SortFlag = 1,
                    Desc = "瞎搞",
                    IsDraft = false,
                    Excerpt = "本片文章用来记录我在Golang开发学习过程中遇到的有关error的一些坑。或许你也遇到，或许你能在这里找到答案。当然通过error的例子，你也应该联想到其它场景。"
                };
                context.Articles.Add(article);
                context.SaveChanges();
                var serart = new SerieArticle()
                {
                    Serie = servi,
                    Article = article
                };
                context.SerieArticles.Add(serart);
                var tagArc=new TagArticle()
                {
                    TagId = tag.TagId,
                    ArticleId = article.ArticleId
                };
                var tagArc2=new TagArticle()
                {
                    TagId = tag1.TagId,
                    ArticleId = article.ArticleId
                };
                context.TagArticles.Add(tagArc);
                context.TagArticles.Add(tagArc2);
                context.SaveChanges();
            }
           
        }
    }
}