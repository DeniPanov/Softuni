class Company {
    constructor() {
        let departments = [];
        let employees = [];
    }

    addEmployee(username, salary, position, department) {
        const params = [username, salary, position, department];

        params.forEach(p => {
              if (p === " " || p === undefined || p === null || salary < 0) {
            throw new Error("Invalid input!");
        }});

        const employee = {
            username,
            salary,
            position,
            department
        };

        this.departments.push(employee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {

    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
