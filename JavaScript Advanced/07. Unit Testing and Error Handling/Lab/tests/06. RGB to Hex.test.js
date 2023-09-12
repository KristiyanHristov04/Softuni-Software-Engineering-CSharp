const rgbToHexColor = require('../06. RGB to Hex');
const assert = require('chai').assert;

describe('RgbToHex Tests', () => {
    it('Return color in hexadecimal format 1', () => {
        assert.equal(rgbToHexColor(67, 59, 71), '#433B47');
    });

    it('Return color in hexadecimal format 2', () => {
        assert.equal(rgbToHexColor(255, 158, 170), '#FF9EAA');
    });

    it('Return undefined out of down range first argument', () => {
        assert.equal(rgbToHexColor(-1, 1, 1), undefined);
    });

    it('Return undefined out of down range second argument', () => {
        assert.equal(rgbToHexColor(1, -1, 1), undefined);
    });

    it('Return undefined out of down range third argument', () => {
        assert.equal(rgbToHexColor(1, 1, -1), undefined);
    });

    it('Return undefined out of up range first argument', () => {
        assert.equal(rgbToHexColor(256, 0, 0), undefined);
    });

    it('Return undefined out of up range second argument', () => {
        assert.equal(rgbToHexColor(0, 256, 0), undefined);
    });

    it('Return undefined out of up range third argument', () => {
        assert.equal(rgbToHexColor(0, 0, 256), undefined);
    });

    it('Return undefined if not a number first argument', () => {
        assert.equal(rgbToHexColor(true, 1, 1), undefined);
    });

    it('Return undefined if not a number second argument', () => {
        assert.equal(rgbToHexColor(1, 'a', 1), undefined);
    });

    it('Return undefined if not a number third argument', () => {
        assert.equal(rgbToHexColor(1, 1, 5.5), undefined);
    });

    it('Return undefined if 2 arguments are not integers', () => {
        assert.equal(rgbToHexColor(1.1, 1.1, 5), undefined);
    });

    it('Return undefined if all arguments are not integers', () => {
        assert.equal(rgbToHexColor(1.1, 1.1, 1.1), undefined);
    });

    it('Return undefined ', () => {
        assert.equal(rgbToHexColor(1.1, -5, 300), undefined);
    });

    it('Test1', () => {
        assert.equal(rgbToHexColor(15, 15, 15), '#0F0F0F');
    });

    it('Test2', () => {
        assert.notEqual(rgbToHexColor(15, 15, 15), '#0f0f0f');
    });

    it('Test3', () => {
        assert.notEqual(rgbToHexColor(15, 15, 15), '#fff');
    });

    it('Test4', () => {
        assert.notEqual(rgbToHexColor(15, 15, 15), '#FFF');
    });

    it('Test5', () => {
        assert.equal(rgbToHexColor(0, 0, 0), '#000000');
    });
});