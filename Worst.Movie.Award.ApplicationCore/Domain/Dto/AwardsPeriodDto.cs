﻿namespace Worst.Movie.Award.ApplicationCore.Domain.Response
{
    public class AwardsPeriodDto
    {
        public string Producer { get; set; }
        public int Interval { get; set; }
        public int PreviousWin { get; set; }
        public int FollowingWin { get; set; }
    }
}
