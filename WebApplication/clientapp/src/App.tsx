import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import './App.css';
import Home from './components/home/Home';
import repositoryReducer from './store/reducers/repositoryReducer';
import { Provider } from 'react-redux';
import {createStore, applyMiddleware, combineReducers} from 'redux';
import thunk from 'redux-thunk';
import asyncComponent from "./hoc/AsyncComponent";
import internalServer from "./components/errorpages/InternalServer";
import NotFound from "./components/errorpages/NotFound";
import errorHandlerReducer from "./store/reducers/errorHandlerReducer";

const rootReducers = combineReducers({
    repository: repositoryReducer,
    errorHandler: errorHandlerReducer
})
const store = createStore(rootReducers, applyMiddleware(thunk));
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
                    <Route path='/owner-list' component={AsyncOwnerList} />
                    <Route path='/500' component={internalServer} />
                    <Route path='*' component={NotFound} />
                </Switch>
            </Router>
        </div>
      </Provider>
  );
}

export default App;
