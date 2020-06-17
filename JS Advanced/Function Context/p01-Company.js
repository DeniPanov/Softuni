class Company {
    constructor() {
        this.departments = [];
        this.employees = [];
    }

    addEmployee(username, salary, position, department) {
        this._validateParam(username);
        this._validateParam(salary);
        this._validateParam(position);
        this._validateParam(department);

        if (salary < 0) {
            throw new Error(`Invalid input!`);
        };

        let current = this.departments.find(d => d.name === department);

        if (current === undefined) {
            current = {
                name: department,
                employees: []
            };
            this.departments.push(current);
        }

        current.employees.push({
            username,
            salary,
            position
        });

        return `New employee is hired. Name: ${username}. Position: ${position}`

    }

    bestDepartment() {
        const department = this.departments.map(d => {
            const dep = Object.assign({}, d);
            dep.averageSalary = d.employees.reduce((p, c, i, a) => p + c.salary, 0) / d.employees.length;
            return dep;
        });
        department.sort((a, b) => b.averageSalary - a.averageSalary);
        const best = department[0];
        if (best !== undefined) {
            best.employees.sort((a, b) => b.salary - a.salary
                || a.username.localeCompare(b.username));

            const result = [
                `Best Department is: ${best.name}`,
                `Average salary: ${best.averageSalary.toFixed(2)}`,
            ]
            best.employees.forEach(e => result.push(`${e.username} ${e.salary} ${e.position}`))
            return result.join('\n');
        }
    }

    _validateParam(param) {
        if (param === '' || param === undefined || param === null) {
            throw new Error(`Invalid input!`);
        }
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
