using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeAccounting {
    public class DataBase {
        public IList<Employee> Employees { get; }
        public IList<Department> Departments { get; }
        public IList<Cabinet> Cabinets { get; }
        public IList<Position> Positions { get; }

        public DataBase(XElement element) {
            if (element.Element("Departments") is XElement xElementDepartments) {
                Departments = xElementDepartments.Elements("Department")
                .Select(xElement => Department.FromXElement(xElement)).ToList();
            }
            else
                Departments = new List<Department>();


            if (element.Element("Positions") is XElement xElementPositions) {
                Positions = xElementPositions.Elements("Position")
                .Select(xElement => Position.FromXElement(xElement)).ToList();
            }
            else
                Positions = new List<Position>();


            if (element.Element("Cabinets") is XElement xElementCabinets) {
                Cabinets = xElementCabinets.Elements("Cabinet")
                .Select(xElement => Cabinet.FromXElement(xElement)).ToList();
            }
            else
                Cabinets = new List<Cabinet>();


            if (element.Element("Employees") is XElement xElementEmployees) {
                Employees = xElementEmployees.Elements("Employee")
                .Select(xElement => Employee.FromXElement(xElement)).ToList();
            }
            else
                Employees = new List<Employee>();

        }
    }
}
