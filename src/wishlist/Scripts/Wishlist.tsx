import * as React from "react";
import { render } from "react-dom";

interface IAppState {

}


const Application = (props: IAppState) => {
	return (
		<div>
			<h1>Välkommen till önskelistemaskinen!</h1>
		</div>
	);
};

var element = document.getElementById('WishlistContainer');
render(<Application />, element);