function attachEventsListeners() {
    const distance = document.getElementById('inputDistance');
    const outputDistance = document.getElementById('outputDistance');
    const inputUnits = document.getElementById('inputUnits');
    const outputUnits = document.getElementById('outputUnits');
    const inputButton = document.getElementById('convert');
    inputButton.addEventListener('click', calculate);

    function calculate() {
        let distanceValue = Number(distance.value);
        let fromUnit = inputUnits.value;
        let toUnit = outputUnits.value;
        console.log('Distance: ' + distanceValue);
        console.log('Unit: ' + fromUnit)
        console.log('To unit: ' + toUnit);
        let distanceValueToMeters = 0;
        let outputDistanceValue = 0;

        switch (fromUnit) {
            case 'km':
                distanceValueToMeters = distanceValue * 1000;
                break;
            case 'm':
                distanceValueToMeters = distanceValue;
                break;
            case 'cm':
                distanceValueToMeters = distanceValue * 0.01;
                break;
            case 'mm':
                distanceValueToMeters = distanceValue * 0.001;
                break;
            case 'mi':
                distanceValueToMeters = distanceValue * 1609.34;
                break;
            case 'yrd':
                distanceValueToMeters = distanceValue * 0.9144;
                break;
            case 'ft':
                distanceValueToMeters = distanceValue * 0.3048;
                break;
            case 'in':
                distanceValueToMeters = distanceValue * 0.0254;
                break;
        }

        switch (toUnit) {
            case 'km':
                outputDistanceValue = distanceValueToMeters / 1000;
                break;
            case 'm':
                outputDistanceValue = distanceValueToMeters;
                break;
            case 'cm':
                outputDistanceValue = distanceValueToMeters / 0.01;
                break;
            case 'mm':
                outputDistanceValue = distanceValueToMeters / 0.001;
                break;
            case 'mi':
                outputDistanceValue = distanceValueToMeters / 1609.34;
                break;
            case 'yrd':
                outputDistanceValue = distanceValueToMeters / 0.9144;
                break;
            case 'ft':
                outputDistanceValue = distanceValueToMeters / 0.3048;
                break;
            case 'in':
                outputDistanceValue = distanceValueToMeters / 0.0254;
                break;
        }
        outputDistance.value = outputDistanceValue;
    }
}