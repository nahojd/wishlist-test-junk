import { getStuff } from "./Test";

var stuff = getStuff();
console.debug('Got stuff: ' + stuff);

document.body.insertAdjacentHTML('beforeEnd', `<strong>${stuff}</strong>`);
