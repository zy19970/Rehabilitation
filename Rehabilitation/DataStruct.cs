using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehabilitation
{
    class From1
    {
        public struct M8128{
            public float forceX;//实际力
            public float torqueX ;//实际力矩

            public float forceY;//实际力
            public float torqueY;//实际力矩

            public float forceZ ;//实际力
            public float torqueZ;//实际力矩
        }
        public struct DeDetail{
            public float degreeX;
            public float degreeY;
            public float degreeZ;
        }
    }
    class FTDetail
    {
        public float forceX = 0;//实际力
        public float torqueX = 0;//实际力矩

        public float forceY = 0;//实际力
        public float torqueY = 0;//实际力矩

        public float forceZ = 0;//实际力
        public float torqueZ = 0;//实际力矩
    }
    class DegreeDetail
    {
        public float degreeX = 0;
        public float degreeY = 0;
        public float degreeZ = 0;
    }
}
