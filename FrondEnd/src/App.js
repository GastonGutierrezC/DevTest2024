// App.js
import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import PollForm from './Pages/CreatePollPage'
import PollListPage from './Pages/PollListPage'


function App() {
  return (
    <Router>
      <Routes>

        <Route path='/createPoll' element={<PollForm />} />
        <Route path='/polliList' element={<PollListPage />} />

        
        
      </Routes>
    </Router>
  );
}

export default App;
