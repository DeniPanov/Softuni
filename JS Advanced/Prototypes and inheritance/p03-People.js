function solve() {
    const juniorTasks = [` is working on a simple task.`];
    const seniorTasks = [" is working on a complicated task.",
        " is taking time off work.",
        " is supervising junior workers.",
    ];
    const managerTasks = [" scheduled a meeting.",
        " is preparing a quarterly report.",
    ];

    class Employee {
        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error("Cannot instance an abstract class!")
            }

            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let firstTask = this.tasks.shift();
            console.log(this.name + firstTask);
            this.tasks.push(firstTask);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);

            juniorTasks.forEach(t => this.tasks.push(t));
        }

    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);

            seniorTasks.forEach(t => this.tasks.push(t));
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;

            managerTasks.forEach(t => this.tasks.push(t));
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Junior,
        Senior,
        Manager,
    }
}

let emps = solve();
let j = new emps.Junior("Pesho", 22);
let s = new emps.Senior("Pacho", 33);
let m = new emps.Manager("Pichu", 35);

j.salary = 1500;
s.salary = 3000;
m.salary = 4000;
m.dividend = 1000;

console.log(j.collectSalary());
console.log(s.work());
console.log(s.work());
console.log(m.collectSalary());