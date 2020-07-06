let StringBuilder = require('./string-builder');
let assert = require('chai').assert;

describe('stringBuilder', () => {
    let actualResult;
    let expectedResult;
    beforeEach(() => {
        actualResult = null;
        expectedResult = null;
    });

    describe('constructor', () => {
        it('without param', () => {
            actualResult = new StringBuilder()._stringArray;
            expectedResult = [];

            assert.deepEqual(actualResult, expectedResult);
        });

        it('with param', () => {
            actualResult = new StringBuilder('sth')._stringArray;
            expectedResult = ['s', 't', 'h'];

            assert.deepEqual(actualResult, expectedResult);
        });

        it('with param different from string should throw error', () => {
            actualResult = () => new StringBuilder(true);

            // expectedResult = 'Argument must be string';
            // assert.throw(actualResult,  expectedResult);
            assert.throws(actualResult);
        });
    });

    describe('append', () => {
        it('should work correctly sth + ing = sthing', () => {
            sb = new StringBuilder('sth');
            sb.append('ing');
            actualResult = sb._stringArray;
            expectedResult = ['s', 't', 'h', 'i', 'n', 'g'];

            assert.deepEqual(actualResult, expectedResult);
        });

        it('should not append non string', () => {
            sb = new StringBuilder('sth');
            actualResult = () => sb.append(true);

            expectedResult = 'Argument must be string';
            assert.throw(actualResult, expectedResult);
        });
    });

    describe('prepend', () => {
        it('should work correctly sth.prend(ing) = ingsth', () => {
            sb = new StringBuilder('sth');
            sb.prepend('ing');
            actualResult = sb._stringArray;
            expectedResult = ['i', 'n', 'g', 's', 't', 'h'];

            assert.deepEqual(actualResult, expectedResult);
        });

        it('should not prepend non string value', () => {
            sb = new StringBuilder('sth');
            actualResult = () => sb.prepend(true);

            assert.throws(actualResult);
        });
    });

    describe('insertAt', () => {
        it('should inset correctly', () => {
            sb = new StringBuilder('sth');
            sb.insertAt('ome', 1);
            actualResult = sb._stringArray;
            expectedResult = ['s', 'o', 'm', 'e', 't', 'h'];

            assert.deepEqual(actualResult, expectedResult);
        });
        it('should not insert non string value', () => {
            sb = new StringBuilder('sth');
            actualResult = () => sb.insertAt(true, 0);

            assert.throws(actualResult);
        });
    });

    describe('remove', () => {
        it('should work correctly', () => {
            sb = new StringBuilder('sth');
            sb.remove(1, 2);
            actualResult = sb._stringArray;
            expectedResult = ['s'];

            assert.deepEqual(actualResult, expectedResult);
        });
    })

    describe('toString', () => {
        it('should work correctly', () => {
            sb = new StringBuilder('sth');
            actualResult = sb.toString();
            expectedResult = 'sth'

            assert.equal(actualResult, expectedResult);
        });
    });

    describe('_vrfyParam', () => {
        it('should throw error', () => {
            assert.throws(() => StringBuilder._vrfyParam(true));
        });
        it('should not throw parameter', ()=>{
            assert.doesNotThrow(()=>StringBuilder._vrfyParam('sth'));
        });
    });
});