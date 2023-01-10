import { NavItem } from 'react-bootstrap';
import Nav from 'react-bootstrap/Nav';
import { useNavigate } from 'react-router-dom'
import "../../Style/navbar.css"

const NavbarLinks = ({ role }) => {

    const navigate = useNavigate()

    function navigateTo(e, url) {
        
        navigate(url);
    }
    // eslint-disable-next-line default-case
    switch(role){
        case "Government":
            return (
                <>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/schools")}> All Schools </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/schooladmins")}> School Administrator </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/students")}> All Students </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "/govadmin/teachers")}> Teacher related page </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schooladmin/register")}> Add new user </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "govadmin/addschool")}> Add new school</button>
                   
                </>
            )
        case "SchoolAdmin":
            return(
                <>
                    <Nav.Link href="schooladmin/register">Add new user</Nav.Link>
                    <NavItem> not available yet...</NavItem>
                    <Nav.Link href="allschooladmins">School related page</Nav.Link>
                    <Nav.Link href="allteachers">Teacher related page</Nav.Link>
                    <Nav.Link href="">Lessons/Timetable</Nav.Link>
                    <Nav.Link href="allstudents">Students/Marks</Nav.Link>
                </>
            )

        case "Teacher":
            return(
                <>
                    <NavItem> not available yet...</NavItem>
                    <Nav.Link href="teachers">Teachers</Nav.Link>
                    <Nav.Link href="schools">Schools</Nav.Link>
                    <Nav.Link href="lessons">Lessons</Nav.Link>
                    <Nav.Link href="allstudents">Students</Nav.Link>
                </>
            )

        case "Student":
            return(
                <>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "student/myschool")}> Schools related page </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "teachers")}> Teachers </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "schools")}> Schools </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "lessons")}> Lessons </button>
                    <button  className='navbar-direction-button' typeof='button' onClick={(e) => navigateTo(e, "marks")}> Marks </button>
                    
                    <button  className='navbar-direction-button profile' typeof='button' onClick={(e) => navigateTo(e, "profile")}> Show profile </button>
                </>
            )

        case "Parent":
            return(
                <>
                    <Nav.Link href="students">My child</Nav.Link>
                    <Nav.Link href="teachers">Teachers</Nav.Link>
                    <Nav.Link href="lessons">Lessons</Nav.Link>
                </>
            )
        
        
    }
}
export default NavbarLinks;
