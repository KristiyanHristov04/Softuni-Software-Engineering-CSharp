function figureArea(input){
    let figure = input[0];
    let figureArea = 0;
    if (figure == 'square') {
        let a = Number(input[1]);
        figureArea = a * a;
        console.log(figureArea.toFixed(3));
    }
    else if(figure == 'rectangle'){
        let l = Number(input[1]);
        let w = Number(input[2]);
        figureArea = l * w;
        console.log(figureArea.toFixed(3));
    }
    else if(figure == 'circle'){
        let r = Number(input[1]);
        figureArea = Math.pow(r, 2) * Math.PI;
        console.log(figureArea.toFixed(3));
    }
    else if(figure == 'triangle'){
        let b = Number(input[1]);
        let h = Number(input[2]);
        figureArea = (b * h) / 2;
        console.log(figureArea.toFixed(3));
    }
}

figureArea(['square', '5']);
figureArea(['rectangle', '7', '2.5']);
figureArea(['circle', '6']);
figureArea(['triangle', '4.5', '20']);