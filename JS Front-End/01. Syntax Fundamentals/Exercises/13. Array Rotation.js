function solve(array, rotations){
   while(rotations > 0){
        let removedElement = array.shift();
        array.push(removedElement);
        rotations--;
   }
   console.log(array.join(' '));
}

solve([2, 4, 15, 31], 5);