const assert = require('chai').assert;
const {createCalculator} = require('../07. Add Subtract');

describe('Tests', () => {
    it('test add method integers', () => {
        const calculator = createCalculator();

        calculator.add(1);
        assert.equal(calculator.get(), 1);

        calculator.add(2);
        assert.equal(calculator.get(), 3);
    });

    it('test add method strings', () => {
        const calculator = createCalculator();

        calculator.add('1');
        assert.equal(calculator.get(), 1);

        calculator.add('2');
        assert.equal(calculator.get(), 3);
    });

    it('test subtract method', () => {
        const calculator = createCalculator();
        
        calculator.subtract(5);
        assert.equal(calculator.get(), -5);

        calculator.subtract(2);
        assert.equal(calculator.get(), -7);
    });

    it('test get method', () => {
        const calculator = createCalculator();

        assert.equal(calculator.get(), 0);

    });
});