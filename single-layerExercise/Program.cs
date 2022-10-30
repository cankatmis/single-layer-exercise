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
            List<User> users = UserTweetManager.XMLReader().ToList();

            foreach (var user in users)
            {
                if (Validator.UserEmailValidator(nameof(user.UserEmail), user))
                {
                    ctx.Users.Add(user);
                }
                else
                {
                    Console.WriteLine($"{user}: not fulfilled the requirements.\n");
                }
            }
            ctx.SaveChanges();

            UserTweetManager.GetUsersWithHotmailAccount(ctx).ToConsole("Get Users With Hotmail Account");
            UserTweetManager.GetUsersWithAtLeastOneOldTweet(ctx).ToConsole("Get Users With AtLeast One Old Tweet");
            UserTweetManager.GetUsersWithTweetCount(ctx).ToConsole("Get Users With Tweet Count");
            UserTweetManager.AverageTweetLengthByFlag(ctx).ToConsole("Average Tweet Length By Flag");
            UserTweetManager.SumOfTweetYearsByFlag(ctx).ToConsole("Sum Of Tweet Years By Flag");
            UserTweetManager.GetTweetNumberForMailType(ctx).ToConsole("Get Tweet Number For Mail Type");

        }
    }
}
