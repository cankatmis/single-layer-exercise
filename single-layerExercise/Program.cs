using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace single_layerExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserTweetContext ctx = new UserTweetContext();
            User u = new User();
            u.UserName = "test_user";
            u.UserEmail = "aaa@gmail.com";
            u.Tweets = new List<Tweet>();
            u.Tweets.Add(new Tweet()
            {
                Content = "aaaadfadfadf",
                Flagged = true,
                Year = 2022
            });

            ctx.Users.Add(u);
            ctx.SaveChanges();

            foreach (var item in ctx.Users)
            {
                Console.WriteLine(item);
            }

            List<User> users = UserTweetManager.XMLReader().ToList();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.UserName}");
                foreach (var tweets in item.Tweets)
                {
                    Console.WriteLine(tweets.Content);
                }
                Console.WriteLine("---");
            }

            foreach (var user in users)
            {
                if (Validator.UserEmailValidator(nameof(user.UserEmail), user))
                {
                    ctx.Users.Add(user);
                }
                else
                {
                    Console.WriteLine($"{user} was not fulfilled the requiremenets!");
                }
            }
            ctx.SaveChanges();

            UserTweetManager.GetUsersWithHotmailAccount(ctx).ToConsole("Q1");
            UserTweetManager.GetUsersWithAtLeastOneOldTweet(ctx).ToConsole("Q2");
            UserTweetManager.GetUsersWithTweetCount(ctx).ToConsole("Q3");
            UserTweetManager.AverageTweetLengthByFlag(ctx).ToConsole("Q4");
            UserTweetManager.SumOfTweetYearsByFlag(ctx).ToConsole("Q5");
            UserTweetManager.GetTweetNumberForMailType(ctx).ToConsole("Q6");

        }
    }
}
