import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Home from './components/home/Home';
// import Profile from './components/Profile';
// import OwnerList from "./components/owner/OwnerList.js";
import repositoryReducer from './store/reducers/repositoryReducer';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import asyncComponent from "./hoc/AsyncComponent";

const store = createStore(repositoryReducer, applyMiddleware(thunk));
const AsyncOwnerList = asyncComponent(() => {
    return import('./components/owner/OwnerList');
});

function App() {
  return (
      <Provider store={store}>
        <div className='App'>
            <Router>
                Hello there. We need to communicate with the controller through a API calls.
                Let's configure some simple routing
                <Switch>
                    <Route exact path='/' component={Home} />
                    <Route path="/owner-list" component={AsyncOwnerList} />
                    <Route exact path='/:id' component={Home} />
                </Switch>
            </Router>
        </div>
      </Provider>
  );
}

export default App;
