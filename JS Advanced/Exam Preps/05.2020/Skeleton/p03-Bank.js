class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        let currentCustomer = this.allCustomers.find(c => c.personalId === customer.personalId);

        if (currentCustomer !== undefined) {
            throw new Error(`${currentCustomer.firstName} ${currentCustomer.lastName} is already our customer!`);
        }

        customer.totalMoney = 0;
        customer.transactions = [];
        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error("We have no customer with this ID!");
        }

        customer.totalMoney += amount;
        customer.transactions.unshift(`${customer.transactions.length + 1}. ${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        return `${customer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error("We have no customer with this ID!");
        } else if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        customer.transactions.unshift(`${customer.transactions.length + 1}. ${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

        return `${customer.totalMoney}$`;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find(c => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error("We have no customer with this ID!");
        }

        let result = [
            `Bank name: ${this._bankName}`,
            `Customer name: ${customer.firstName} ${customer.lastName}`,
            `Customer ID: ${personalId}`,
            `Total Money: ${customer.totalMoney}$`,
            `Transactions:`
        ].concat(customer.transactions)
            .join("\n");

        return result;
    }
}

let bank = new Bank("SoftUni Bank");

console.log(bank.newCustomer({ firstName: "Svetlin", lastName: "Nakov", personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: "Mihaela", lastName: "Mileva", personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
