let mathEnforcer = require('./mathEnforcer');
let assert = require('chai').assert;

describe('mathEnforcer', () => {
    describe('addFive function', () => {
        it('should return undefined with non number parameter', () => {
            let result = mathEnforcer.addFive('hello');
            assert.isUndefined(result);
        });
        it('should increment 5 with 5 => 10', () => {
            let result = mathEnforcer.addFive(5);
            assert.equal(result, 10);
        });
        it('should add 5 to floating number 5+3.14=8.14', ()=>{
            let result = mathEnforcer.addFive(3.14);
            assert.closeTo(result, 8.14, 0.01);
        })
        it('should add 5 to negative number -10+5=-5', ()=>{
            let result = mathEnforcer.addFive(-10);
            assert.equal(result, -5);
        })
    });

    describe('subtractTen function', () => {
        it('should return undefined with non number parameter', () => {
            let result = mathEnforcer.subtractTen('ff');
            assert.isUndefined(result);
        });
        it('should subtract 15-10=5', () => {
            let result = mathEnforcer.subtractTen(15);
            assert.equal(result, 5);
        });
        it('should subtract from floating number 10.1-10 = 0.1',()=>{
            let result = mathEnforcer.subtractTen(10.1);
            assert.closeTo(result, 0.1, 0.01);
        });
        it("should return correct result for negative integer parameter", function () {
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        });
    });

    describe('sum', () => {
        it('should return undefined with parameter 1 not a number', () => {
            let result = mathEnforcer.sum('hello', 1);
            assert.isUndefined(result);
        });
        it('should return undefined with parameter 2 not a number', () => {
            let result = mathEnforcer.sum(1, 'hello');
            assert.isUndefined(result);
        });
        it('should not parse \'5\' to 5', () => {
            let result = mathEnforcer.sum('5', 5);
            assert.isUndefined(result);
        });
        it('should return undefined with non number parameters', () => {
            let result = mathEnforcer.sum('hello', 'hello');
            assert.isUndefined(result);
        });
        it('should sum correctly 5+5=10', () => {
            let result = mathEnforcer.sum(5, 5);
            assert.equal(result, 10);
        });
        it('should sum negative -5+(-5)=-10', ()=>{
            let result = mathEnforcer.sum(-5, -5);
            assert.equal(result, -10);
        });
        it('should sum floating number 3.14+3.14 = 6.28', ()=>{
            let result = mathEnforcer.sum(3.14, 3.14);
            assert.closeTo(result, 6.28, 0.01);
        });
    });
});