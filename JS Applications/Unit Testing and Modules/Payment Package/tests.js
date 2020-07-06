let PaymentPackage = require('./paymentPackage');
let assert = require('chai').assert;

describe('PaymentPackage', () => {
    let paymentPackage;
    beforeEach(() => {
        paymentPackage = new PaymentPackage('a', 1);
    });

    describe('name', () => {
        it('should return correctly', () => {
            let expectedResult = 'a';

            assert.equal(paymentPackage.name, expectedResult);
        });
        it('should work correctly', () => {
            paymentPackage.name = 'b';
            let expectedResult = 'b';
            assert.equal(paymentPackage.name, expectedResult);
        });
        it('set name should not set non string value', () => {
            let result = () => paymentPackage.name = 1;
            assert.throw(result, 'Name must be a non-empty string');
        });
        it('set name should not set string with zero length', () => {
            let result = () => paymentPackage.name = '';
            assert.throw(result, 'Name must be a non-empty string');
        });
    });
    describe('value', () => {
        it('should work correctly', () => {
            let expectedResult = 1;
            assert.equal(paymentPackage.value, expectedResult);
        });
        it('should set correctly', () => {
            let expectedResult = 2;
            paymentPackage.value = 2;
            assert.equal(paymentPackage.value, expectedResult);
        });
        it('set value should not set non number value ', () => {
            let result = () => paymentPackage.value = 'string';
            assert.throw(result, 'Value must be a non-negative number');
        });
        it('set value should set number below zero', () => {
            let result = () => paymentPackage.value = -50;
            assert.throw(result, 'Value must be a non-negative number');
        });
    });
    describe('VAT', () => {
        it('should work correctly', () => {
            let expectedResult = 20;
            assert.equal(paymentPackage.VAT, expectedResult);
        });
        it('set VAT should set number value ', () => {
            paymentPackage.VAT = 30;
            let expectedResult = 30;
            assert.equal(paymentPackage.VAT, expectedResult);
        });
        it('set VAT should not set non number value ', () => {
            let result = () => paymentPackage.VAT = 'string';
            assert.throw(result, 'VAT must be a non-negative number');
        });
        it('set VAT should set number below zero', () => {
            let result = () => paymentPackage.VAT = -50;
            assert.throw(result, 'VAT must be a non-negative number');
        });
    });
    describe('active', () => {
        it('active should work correctly', () => {
            assert.isTrue(paymentPackage.active);
        });
        it('set active to false', () => {
            paymentPackage.active = false;
            assert.isFalse(paymentPackage.active);
        });
        it('set active should not set non boolean value', () => {
            let result = () => paymentPackage.active = 'sth';
            assert.throw(result, 'Active status must be a boolean');
        });
    });
    describe('toString', () => {
        it("should work correctly when active = true", () => {
            let expectedResult = 'Package: a\n- Value (excl. VAT): 1\n- Value (VAT 20%): 1.2';

            assert.equal(paymentPackage.toString(), expectedResult);
        });
        it("should work correctly when active = false", () => {
            paymentPackage.active = false;
            let expectedResult = 'Package: a (inactive)\n- Value (excl. VAT): 1\n- Value (VAT 20%): 1.2';

            assert.equal(paymentPackage.toString(), expectedResult);
        });
    });
});