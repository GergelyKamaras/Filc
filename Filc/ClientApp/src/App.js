

import './App.css';
import { Routes, Route } from 'react-router-dom'
import Layout from './Pages/Shared/Layout'
import RequireAuth from './Pages/Other/RequireAuth';
import Unauthorized from './Pages/Other/Unauthorized';
import NotFound from './Pages/Other/NotFound';
import SchoolAdmins from './Pages/SchoolAdmin/SchoolAdmins';
import SchoolAdmin from './Pages/SchoolAdmin/SchoolAdmin';
import Schools from './Pages/Schools/Schools';
import School from './Pages/Schools/School';
import IndexPage from './Pages/Home/AppIndex';
import LoginPage from './Pages/Login/LoginPage';
import RegisterUser from './Pages/Registration/RegisterUser';

function App() {


    return (
        <Routes>
            <Route path="/" element={<Layout />} />

            {/*Routes available to all users*/}
            <Route path="" element={<IndexPage/>} />
            <Route path='/login' element={<LoginPage/>}/>
            <Route path="Unauthorized" element={<Unauthorized />} />
            <Route path="schooladmins/:id" element={<SchoolAdmin />} />

            {/*TODO: Routes available to Students*/}
            <Route element={<RequireAuth allowedRoles={["Student"]} />} />
          
            {/*TODO: Routes available to Teachers*/}
            <Route element={<RequireAuth allowedRoles={["Teacher"]} />} />
          
            {/*TODO: Routes available to SchoolAdmins*/}
            <Route element={<RequireAuth allowedRoles={["SchoolAdmin"]} />} />
            <Route path="register" element={<RegisterUser />} />

            {/*TODO: Routes available to GovAdmins*/}
            <Route path="govadmin" element={<RequireAuth allowedRoles={["GovAdmin"]} />} />
            <Route path="schools/:schoolid/admins" element={<SchoolAdmins />} />
            <Route path="schooladmins/:id" element={<SchoolAdmin />} />
            <Route path="schools/" element={<Schools />} />
            <Route path="schools/:id" element={<School />} />
    
            {/*Not Existing Route*/}
            <Route path="*" element={<NotFound />} />
      </Routes>
    );
}

export default App;
