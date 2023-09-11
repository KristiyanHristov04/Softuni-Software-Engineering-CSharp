const expect = require('chai').expect;
const assert = require('chai').assert;
const sum = require('../04. Sum of Numbers');

describe('Sum Array', () => {
    it('adds numbers', () => {
        //expect(sum([1, 2])).to.equal(3);
        assert.equal(sum([1, 2]), 3);
    });

    it('works with strings', () => {
        expect(sum(['1', '2'])).to.equal(3);
        //assert.equal(sum(['1', '2']), 3);
    });
});