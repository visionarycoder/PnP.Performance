﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Timers;

using ObjectLibrary;
using ObjectLibrary.Factory;
using ObjectLibrary.Messaging;

namespace ConsoleApp
{

    class Program
    {

        static void Main(string[] args)
        {

            foreach (var range in new[] { 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000 })
            {

                var stopwatch = Stopwatch.StartNew();
                foreach (var _ in Enumerable.Range(0, range))
                {
                    var sampleRequest = ServiceMessageFactory_Activator<SampleRequest>.Create();
                    var sampleResponse = ServiceMessageFactory_Activator<SampleResponse>.CreateFrom(sampleRequest);
                    sampleRequest = null;
                    sampleResponse = null;
                }
                Console.WriteLine($"Activator {range:#,0} => {stopwatch.Elapsed}");

                stopwatch.Restart();
                foreach (var _ in Enumerable.Range(0, range))
                {
                    var sampleRequest = ServiceMessageFactory_New<SampleRequest>.Create();
                    var sampleResponse = ServiceMessageFactory_New<SampleResponse>.CreateFrom(sampleRequest);
                    sampleRequest = null;
                    sampleResponse = null;
                }
                Console.WriteLine($"New       {range:#,0} => {stopwatch.Elapsed}");
            }

        }

    }

}