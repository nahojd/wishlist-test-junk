import * as React from "react";
import { render } from "react-dom";
import { Provider, connect } from "react-redux";
import { createStore } from "redux";
import * as _ from "lodash";

interface IAppState {
	name: string;
	friends: Array<string>;
	selectedFriend?: string;
}

declare var initialState: IAppState;

//Reducer
function getWishlistReducer(initialState: IAppState) {
	return (state: IAppState = initialState, action: IAction): IAppState => {
		console.debug(action as any);
		
		switch(ActionTypes[action.type]) {
			case ActionTypes.SelectFriend:
				return _.assign({}, state, { selectedFriend: (action as any).friend }) as IAppState;
		}
		
		return state;
	}
}

//Actions
enum ActionTypes {
	SelectFriend
}

export interface IAction {
	type: string;
}

function selectFriend(friend: string) {
	return {
		type: ActionTypes[ActionTypes.SelectFriend],
		friend: friend
	};
}

function renderApp(data: IAppState, element: Element) {
	let store = createStore(
		getWishlistReducer(data)
	);
	
	render(
		<Provider store={store}>
			<Application />
		</Provider>, 
		element);
}

interface IApplicationProps {
	name?: string;
	friends?: Array<string>;
	selectedFriend?: string;
	
	onFriendClicked?(friend: string): void;
}

@connect(
	(state: IAppState): IApplicationProps => {
		return {
			name: state.name,
			friends: state.friends,
			selectedFriend: state.selectedFriend
		}
	},
	{
		onFriendClicked: selectFriend
	}
)
class Application extends React.Component<IApplicationProps, {}> {
	render() {
		return (
			<div>
				<h1>Välkommen till önskelistemaskinen, {this.props.name}!</h1>
				
				<div className="row">
					<div className="col-xs-4">	
						<ul className="nav nav-pills nav-stacked">
							{this.props.friends.map((friend, index) => 
								<li key={index} className="nav-item">
									<a href="#" 
										className={this.props.selectedFriend === friend ? 'nav-link active' : 'nav-link'} 
										onClick={e => this.props.onFriendClicked(friend)}>{friend}</a>
								</li>
							)}
						</ul>
					</div>
					<div className="col-xs-8">
						Mer content här sen...
					</div>
				</div>
			</div>
		);
	}
}

var element = document.getElementById('WishlistContainer');
renderApp(initialState, element);


