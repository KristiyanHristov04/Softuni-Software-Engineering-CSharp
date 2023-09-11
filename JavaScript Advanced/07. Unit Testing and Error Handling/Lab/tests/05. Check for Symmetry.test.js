const isSymmetric = require('../05. Check for Symmetry');
const assert = require('chai').assert;

describe('Symmetry Tests', () => {
    it('Return false if not an array', () => {
        assert.equal(isSymmetric(5), false);
    });

    it('Return true if array is symmetric integers', () => {
        assert.equal(isSymmetric([1, 2, 1]), true);
    })

    it('Return true if array is symmetric floats', () => {
        assert.equal(isSymmetric([1.5, 2.1, 1.5]), true);
    })

    it('Return true if array is symmetric strings', () => {
        assert.equal(isSymmetric(['5', '1', '5']), true);
    })

    it('Return false if array is not symmetric integers', () => {
        assert.equal(isSymmetric([1, 1, 5]), false);
    })

    it('Return false if array is not symmetric strigs', () => {
        assert.equal(isSymmetric(['5', '1', '6']), false);
    })

    it('Return false mismatched elements', () => {
        assert.equal(isSymmetric([5, '1', '5']), false);
    })
});