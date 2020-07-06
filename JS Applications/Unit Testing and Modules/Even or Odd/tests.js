let isOddOrEven = require('./isOddOrEven');
let assert = require('chai').assert;

describe('isOddOrEven', function () {
    it('should return undefined when parameter is not string', () => {
        let result = isOddOrEven([]);
        assert.isUndefined(result);
    });
    it('should return even when length is even', ()=>{
        assert.equal(isOddOrEven('bird'), 'even');
    });
    it('should return even when length is odd', ()=>{
        assert.equal(isOddOrEven('cat'), 'odd');
    });
})