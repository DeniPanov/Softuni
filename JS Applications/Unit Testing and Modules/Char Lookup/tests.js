let lookupChar = require('./charLookup');
let assert = require('chai').assert;

describe('lookupChar', function () {
    it('should return undefined with wrong params', () => {
        let result = lookupChar([], '22');
        assert.isUndefined(result);
    });

    it('should return undefined with non string param', () => {
        let result = lookupChar([], 2);
        assert.isUndefined(result);
    });

    it('should return undefined with non number param', () => {
        let result = lookupChar('hello', []);
        assert.isUndefined(result);
    });

    it('should return \'Incorrect index\' with index below zero', () => {
        let result = lookupChar('hello', -1);
        assert.equal(result, 'Incorrect index');
    });

    it('with a floating point number second parameter should return undefined', function () {
        assert.isUndefined(lookupChar('hello', 3.33));
    });

    it('should return \'Incorrect index\' with index bigger or equal to string length', () => {
        let result = lookupChar('hello', 5);
        assert.equal(result, 'Incorrect index');
    });

    it('should return e from the string hello', () => {
        let result = lookupChar('hello', 1);
        assert.equal(result, 'e');
    });
    
    it('should work correctly', () => {
        assert.equal(lookupChar('cat', 1), 'a');
        assert.equal(lookupChar('cat', 0), 'c');
        assert.equal(lookupChar('cat', 2), 't');
    });
});