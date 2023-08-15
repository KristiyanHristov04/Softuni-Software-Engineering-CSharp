function solve() {
   let textarea = document.getElementsByTagName('textarea')[0];
   let buttons = Array.from(document.getElementsByTagName('button'));
   buttons.pop();
   let checkoutButton = document.getElementsByClassName('checkout')[0];
   checkoutButton.addEventListener('click', checkoutHandler);
   let totalPrice = 0;
   let boughtItems = [];
   for (const button of buttons) {
      button.addEventListener('click', addHandler);
   }

   function addHandler(event) {
      let currentButton = event.currentTarget;
      let parent = currentButton.parentElement.parentElement;
      let children = parent.children;
      let name = children[1].children[0].textContent;
      let price = Number(children[3].textContent);
      totalPrice += price;
      if (!boughtItems.includes(name)) {
         boughtItems.push(name);
      }
      textarea.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
   }

   function checkoutHandler() {
      textarea.value += `You bought ${boughtItems.join(', ')} for ${totalPrice.toFixed(2)}.`;
      let buttonsToDisable = Array.from(document.getElementsByTagName('button'));
      for (const button of buttonsToDisable) {
         button.disabled = true;
      }
   }
}