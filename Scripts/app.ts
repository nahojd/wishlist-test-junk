import { getStuff } from "./Test";

var stuff = getStuff();
console.debug('Got stuff: ' + stuff);

document.getElementById('main').insertAdjacentHTML('beforeEnd', `<strong>${stuff}</strong>`);
