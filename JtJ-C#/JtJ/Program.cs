using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.IO;
using System.Text.RegularExpressions;
namespace JtJ
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<double> J = Matrix<double>.Build.Dense(125, 8);
            string[] all = File.ReadAllLines("in.txt");
            for (int i = 0; i < all.Length; i++)
            {
                string[] eachline = all[i].Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < eachline.Length - 1; j++)
                {
                    J[i, j] = double.Parse(eachline[j]);
                }
            }

            Matrix<double> Jt = J.Transpose();
            Matrix<double> JtJ = Jt * J;
            File.WriteAllText("out.txt", JtJ.ToString());

            //分解成行向量
            double[][] a = Jt.ToColumnArrays();
            Vector<double> p = Vector.Build.Dense(a[1]);
            //分解成列向量
            double[][] a1 = Jt.ToRowArrays();
            Vector<double> q = Vector.Build.Dense(a1[1]);
            Console.WriteLine(p);
            Console.WriteLine(q);

            //生成vector
            double[] v = new double[3];
            double[] v1 = new double[3];
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = i+1;
                v1[i] = (i+1)*(i+1);
            }
            Vector<double> vec = Vector.Build.Dense(v);
            Vector<double> vec1 = Vector.Build.Dense(v1);

            //点积，返回类型是double
            double vv = vec.DotProduct(vec1);

            Matrix<double> M = Matrix<double>.Build.Dense(3, 5);
            //生成矩阵
            for (int i = 0; i <M.RowCount; i++)
            {
                for (int j = 0; j <M.ColumnCount ; j++)
                {
                    M[i, j] = i + j;
                }
            }
            Console.WriteLine(M);

            //向量与矩阵的乘积--返回向量
            Vector<double> tt = vec * M;


            //矩阵与向量的乘积--返回向量
            double[] v2 = new double[5];
            for (int i = 0; i < v2.Length; i++)
            {
                v2[i] = (i + 1) * (i + 1);
            }
            Vector<double> vec2 = Vector.Build.Dense(v2);
            Vector<double> dd =  M*vec2 ;


        }
    }
}
