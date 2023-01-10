
import {IoIosHome, IoMdPerson } from 'react-icons/io';

const Icon = (props) =>{
    console.log(props.pageTitle)
    if(props.pageTitle === "Home page"){
        return (
            <IoIosHome className='icon'/>
        )
    }
    else if (props.pageTitle === "Profile page"){
        return(
            <IoMdPerson className='icon'/>
        )
    }
}

export default Icon;