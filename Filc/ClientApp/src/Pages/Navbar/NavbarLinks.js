import { NavItem } from 'react-bootstrap';
import Nav from 'react-bootstrap/Nav';

const NavbarLinks = ({ role }) => {

    // eslint-disable-next-line default-case
    switch(role){
        case "Government":
            return (
                <>
                    <Nav.Link href="/govadmin/schools">All Schools</Nav.Link>
                    <Nav.Link href="/govadmin/schooladmins">School Administrator</Nav.Link>
                    <Nav.Link href="/govadmin/students">All Students</Nav.Link>
                    <Nav.Link href="/govadmin/teachers">Teacher related page</Nav.Link>
                    <Nav.Link href="schooladmin/register">Add new user</Nav.Link>
                    <Nav.Link href="govadmin/addschool">Add new school</Nav.Link>
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
                    <NavItem> not available yet...</NavItem>
                    <Nav.Link href="student/myschool">Schools related page</Nav.Link>
                    <Nav.Link href="teachers">Teachers</Nav.Link>
                    <Nav.Link href="schools">Schools</Nav.Link>
                    <Nav.Link href="lessons">Lessons</Nav.Link>
                    <Nav.Link href="marks">Marks</Nav.Link>
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
