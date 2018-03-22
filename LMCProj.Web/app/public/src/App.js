import React, { Component } from 'react';
import Test from './Views/Test';
import Home from './Views/Home';
import TaskManager from './Views/TaskManager';
import Links from './Views/Links';

import { BrowserRouter as Router, Route, Link } from "react-router-dom";

const App = () => (
  <Router>
    <div>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark p-2 mb-3">
        <span className="navbar-brand mb-0 h1">LMC</span>
        <div className="navbar-nav">
          <li>
            <Link className="nav-item nav-link" to="/">Home</Link>
          </li>
          <li>
            <Link className="nav-item nav-link" to="/taskmanager">Task Manager</Link>
          </li>
          <li>
            <Link className="nav-item nav-link" to="/links">Coding Articles</Link>
          </li>
            <Link className="nav-item nav-link" to="/about">About</Link>
          <li>
            <Link className="nav-item nav-link" to="/test">Test</Link>
          </li>
        </div>
      </nav>

      <Route exact path="/" component={Home} />
      <Route path="/taskmanager" component={TaskManager} />
      <Route path="/links" component={Links} />
      <Route path="/about" component={About} />
      <Route path="/test" component={Test} />
    </div>
  </Router>
);

// const Home = () => (
//   <div>
//     <h2>Home</h2>
//   </div>
// );

const About = () => (
  <div>
    <h2>About</h2>
  </div>
);

const Topics = ({ match }) => (
  <div>
    <h2>Topics</h2>
    <ul>
      <li>
        <Link to={`${match.url}/rendering`}>Rendering with React</Link>
      </li>
      <li>
        <Link to={`${match.url}/components`}>Components</Link>
      </li>
      <li>
        <Link to={`${match.url}/props-v-state`}>Props v. State</Link>
      </li>
    </ul>

    <Route path={`${match.url}/:topicId`} component={Topic} />
    <Route
      exact
      path={match.url}
      render={() => <h3>Please select a topic.</h3>}
    />
  </div>
);

const Topic = ({ match }) => (
  <div>
    <h3>{match.params.topicId}</h3>
  </div>
);

export default App;
