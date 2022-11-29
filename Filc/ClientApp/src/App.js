

import './App.css';
import { Route, Routes } from 'react-router';
import IndexPage from './Pages/AppIndex';
import LoginPage from './Pages/LoginPage';

function App() {


    return (
        <div className="App">
            <Routes>
                <Route path='/' element={<IndexPage/>}/>
                <Route path='/login' element={<LoginPage/>}/>
            </Routes>
            
        </div>
    );
}

export default App;
