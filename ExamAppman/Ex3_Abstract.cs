using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamAppman
{
    // C# program to illustrate the 
    // concept of abstract class 
    using System;

    // abstract class 'G' 
    public abstract class G
    {

        // abstract method 'gfg1()' 
        public abstract void gfg1();
    }

    // class 'G' inherit 
    // in child class 'G1' 
    public class G1 : G
    {

        // abstract method 'gfg1()' 
        // declare here with 
        // 'override' keyword 
        public override void gfg1()
        {
            Console.WriteLine("Class name is G1");
        }
    }

    // class 'G' inherit in 
    // another child class 'G2' 
    public class G2 : G
    {

        // same as the previous class 
        public override void gfg1()
        {
            Console.WriteLine("Class name is G2");
        }
    }

    // Driver Class 
    public class main_method
    {

        // Main Method 
        public void Main()
        {
            G g = new G1();

            show(new G1());
            show(new G2());
        }

        public void show(G obj)
        {
            obj.gfg1();
        }
    }

    interface a
    {
        void a1();

    }

    class aa : a
    {
        public void a1()
        {
            throw new NotImplementedException();
        }
    }

}
