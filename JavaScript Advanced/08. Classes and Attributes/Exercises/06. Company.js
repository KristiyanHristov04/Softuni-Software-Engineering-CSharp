class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        this.validateParameters(name, salary, position, department);
        if (salary < 0) {
            throw new Error('Invalid input!');
        }

        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = [{ name, salary, position }];
            return `New employee is hired. Name: ${name}. Position: ${position}`;
        } else {
            this.departments[department].push({ name, salary, position });
            return `New employee is hired. Name: ${name}. Position: ${position}`;
        }
    }

    bestDepartment() {
        let bestDepartment = '';
        let bestDepartmentAvgSalary = 0;
        let departmentsEntries = Object.entries(this.departments);
        for (let i = 0; i < departmentsEntries.length; i++) {
            let currentDepartmentAvgSalary = 0;
            let departmentEmployeesLength = departmentsEntries[i][1].length;
            let departmentName = departmentsEntries[i][0];
            for (let j = 0; j < departmentsEntries[i][1].length; j++) {
                currentDepartmentAvgSalary += departmentsEntries[i][1][j].salary;
            }
            currentDepartmentAvgSalary /= departmentEmployeesLength;
            if (currentDepartmentAvgSalary > bestDepartmentAvgSalary) {
                bestDepartmentAvgSalary = currentDepartmentAvgSalary;
                bestDepartment = departmentName;
            }
        }

        let output = '';
        output += `Best Department is: ${bestDepartment}\n`;
        output += `Average salary: ${bestDepartmentAvgSalary.toFixed(2)}\n`;
        let deparment = this.departments[bestDepartment].sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name));
        for (const employee in deparment) {
            output += `${deparment[employee].name} ${deparment[employee].salary} ${deparment[employee].position}\n`;
        }

        return output.trimEnd();
    }

    validateParameters(...params) {
        for (let index = 0; index < params.length; index++) {
            if (params[index] === null || params[index] === undefined || params[index] === '') {
                throw new Error('Invalid input!');
            }
        }
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
