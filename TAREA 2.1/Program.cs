using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA_2._1
{
    internal class Program
    {
        static void Main()
        {
            // Declaración de variables para estadísticas
            const int maxEmpleados = 100; // Limite arbitrario para la cantidad de empleados
            string[] cedulas = new string[maxEmpleados];
            string[] nombres = new string[maxEmpleados];
            int[] tiposEmpleado = new int[maxEmpleados];
            double[] salariosOrdinarios = new double[maxEmpleados];
            double[] aumentos = new double[maxEmpleados];
            double[] salariosBrutos = new double[maxEmpleados];
            double[] deducciones = new double[maxEmpleados];
            double[] salariosNetos = new double[maxEmpleados];

            int cantidadOperarios = 0;
            int cantidadTecnicos = 0;
            int cantidadProfesionales = 0;

            double acumuladoSalarioNetoOperarios = 0;
            double acumuladoSalarioNetoTecnicos = 0;
            double acumuladoSalarioNetoProfesionales = 0;

            int contadorEmpleados = 0;
            bool continuar = true;

            while (continuar && contadorEmpleados < maxEmpleados)
            {
                // Leer los datos del empleado
                Console.WriteLine("Ingrese el número de cédula del empleado:");
                cedulas[contadorEmpleados] = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre del empleado:");
                nombres[contadorEmpleados] = Console.ReadLine();

                Console.WriteLine("Ingrese el tipo de empleado (1-Operario, 2-Técnico, 3-Profesional):");
                while (!int.TryParse(Console.ReadLine(), out tiposEmpleado[contadorEmpleados]) || tiposEmpleado[contadorEmpleados] < 1 || tiposEmpleado[contadorEmpleados] > 3)
                {
                    Console.WriteLine("Entrada no válida. Ingrese el tipo de empleado (1-Operario, 2-Técnico, 3-Profesional):");
                }

                Console.WriteLine("Ingrese la cantidad de horas laboradas:");
                int horasLaboradas;
                while (!int.TryParse(Console.ReadLine(), out horasLaboradas) || horasLaboradas < 0)
                {
                    Console.WriteLine("Entrada no válida. Ingrese la cantidad de horas laboradas:");
                }

                Console.WriteLine("Ingrese el precio por hora:");
                double precioPorHora;
                while (!double.TryParse(Console.ReadLine(), out precioPorHora) || precioPorHora < 0)
                {
                    Console.WriteLine("Entrada no válida. Ingrese el precio por hora:");
                }

                // Calcular salario ordinario y aumento
                salariosOrdinarios[contadorEmpleados] = horasLaboradas * precioPorHora;

                switch (tiposEmpleado[contadorEmpleados])
                {
                    case 1:
                        aumentos[contadorEmpleados] = salariosOrdinarios[contadorEmpleados] * 0.15;
                        cantidadOperarios++;
                        acumuladoSalarioNetoOperarios += salariosOrdinarios[contadorEmpleados] + aumentos[contadorEmpleados];
                        break;
                    case 2:
                        aumentos[contadorEmpleados] = salariosOrdinarios[contadorEmpleados] * 0.10;
                        cantidadTecnicos++;
                        acumuladoSalarioNetoTecnicos += salariosOrdinarios[contadorEmpleados] + aumentos[contadorEmpleados];
                        break;
                    case 3:
                        aumentos[contadorEmpleados] = salariosOrdinarios[contadorEmpleados] * 0.05;
                        cantidadProfesionales++;
                        acumuladoSalarioNetoProfesionales += salariosOrdinarios[contadorEmpleados] + aumentos[contadorEmpleados];
                        break;
                    default:
                        Console.WriteLine("Tipo de empleado no válido.");
                        continue;
                }

                // Calcular salario bruto, deducción y salario neto
                salariosBrutos[contadorEmpleados] = salariosOrdinarios[contadorEmpleados] + aumentos[contadorEmpleados];
                deducciones[contadorEmpleados] = salariosBrutos[contadorEmpleados] * 0.0917;
                salariosNetos[contadorEmpleados] = salariosBrutos[contadorEmpleados] - deducciones[contadorEmpleados];

                // Mostrar los datos del empleado
                Console.WriteLine($"\nDatos del Empleado:");
                Console.WriteLine($"Cédula: {cedulas[contadorEmpleados]}");
                Console.WriteLine($"Nombre: {nombres[contadorEmpleados]}");
                Console.WriteLine($"Tipo de Empleado: {tiposEmpleado[contadorEmpleados]}");
                Console.WriteLine($"Salario por Hora: {precioPorHora}");
                Console.WriteLine($"Cantidad de Horas: {horasLaboradas}");
                Console.WriteLine($"Salario Ordinario: {salariosOrdinarios[contadorEmpleados]:C}");
                Console.WriteLine($"Aumento: {aumentos[contadorEmpleados]:C}");
                Console.WriteLine($"Salario Bruto: {salariosBrutos[contadorEmpleados]:C}");
                Console.WriteLine($"Deducción CCSS: {deducciones[contadorEmpleados]:C}");
                Console.WriteLine($"Salario Neto: {salariosNetos[contadorEmpleados]:C}");

                // Preguntar si se desea ingresar otro empleado
                Console.WriteLine("\n¿Desea ingresar otro empleado? (s/n)");
                continuar = Console.ReadLine().ToLower() == "s";
                contadorEmpleados++;
            }

            // Mostrar estadísticas
            Console.WriteLine("\nEstadísticas:");
            Console.WriteLine($"Cantidad de Empleados Tipo Operarios: {cantidadOperarios}");
            Console.WriteLine($"Acumulado Salario Neto para Operarios: {acumuladoSalarioNetoOperarios:C}");
            Console.WriteLine($"Promedio Salario Neto para Operarios: {(cantidadOperarios > 0 ? (acumuladoSalarioNetoOperarios / cantidadOperarios) : 0):C}");

            Console.WriteLine($"Cantidad de Empleados Tipo Técnicos: {cantidadTecnicos}");
            Console.WriteLine($"Acumulado Salario Neto para Técnicos: {acumuladoSalarioNetoTecnicos:C}");
            Console.WriteLine($"Promedio Salario Neto para Técnicos: {(cantidadTecnicos > 0 ? (acumuladoSalarioNetoTecnicos / cantidadTecnicos) : 0):C}");

            Console.WriteLine($"Cantidad de Empleados Tipo Profesionales: {cantidadProfesionales}");
            Console.WriteLine($"Acumulado Salario Neto para Profesionales: {acumuladoSalarioNetoProfesionales:C}");
            Console.WriteLine($"Promedio Salario Neto para Profesionales: {(cantidadProfesionales > 0 ? (acumuladoSalarioNetoProfesionales / cantidadProfesionales) : 0):C}");
        }
    }
}
