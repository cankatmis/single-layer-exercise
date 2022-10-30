using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace single_layerExercise
{
    public class UserTweetManager
    {
        public static IEnumerable<User> XMLReader()
        {
            Func<string, IEnumerable<User>> creator = url =>
            {
                XDocument doc = XDocument.Load(url);
                List<User> users = new List<User>();
                foreach (XElement item in doc.Descendants("User"))
                {
                    User user = new User();
                    user.Tweets = new List<Tweet>();
                    user.UserName = item.Element("UserName").Value;
                    user.UserEmail = item.Element("UserEmail").Value;
                    foreach (XElement tweets in item.Descendants("Tweets").Descendants("Tweet"))
                    {
                        Tweet tweet = new Tweet();
                        tweet.Content = tweets.Element("Content").Value;
                        tweet.Flagged = bool.Parse(tweets.Element("Flagged").Value);
                        tweet.Year = int.Parse(tweets.Element("Year").Value);

                        user.Tweets.Add(tweet);
                    }
                    users.Add(user);
                }
                return users;
            };
            return creator("./user-tweets.xml");
        }

        public static IEnumerable<object> GetUsersWithHotmailAccount(UserTweetContext ctx)
        {
            var q = from x in ctx.Users
                    where x.UserEmail.Contains("hotmail")
                    select x.UserName.ToUpper();
            return q;
        }

        public static IEnumerable<object> GetUsersWithAtLeastOneOldTweet(UserTweetContext ctx)
        {
            var q = (from x in ctx.Tweets
                     where x.Year < 2010
                     select x.User).Distinct();
            return q;
        }

        public static IEnumerable<object> GetUsersWithTweetCount(UserTweetContext ctx)
        {
            var q = from x in ctx.Users
                    select new
                    {
                        UserName = x.UserName,
                        TweetCount = x.Tweets.Count()
                    };
            return q;
        }


        public static IEnumerable<object> AverageTweetLengthByFlag(UserTweetContext ctx)
        {
            var q = from x in ctx.Tweets
                    group x by x.Flagged into grp
                    select new
                    {
                        IsFlagged = grp.Key,
                        AverageLength = grp.Average(x => x.Content.Length)
                    };
            return q;
        }

        public static IEnumerable<object> SumOfTweetYearsByFlag(UserTweetContext ctx)
        {
            var q = from x in ctx.Tweets
                    group x by x.Flagged into grp
                    select new
                    {
                        IsFlagged = grp.Key,
                        SumYears = grp.Sum(x => x.Year)
                    };
            return q;
        }

        public static IEnumerable<object> GetTweetNumberForMailType(UserTweetContext ctx)
        {
            var q = from x in ctx.Users.ToList()
                    group x by x.UserEmail.Split('@')[1] into grp
                    select new
                    {
                        MailType = grp.Key,
                        TweetCount = grp.Sum(x => x.Tweets.Count())
                    };

            return q;
        }


    }
}
