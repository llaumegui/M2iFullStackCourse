const ChildrenComponent = (props) => {
    console.log(props);

    return ( 
        <>
            {props.children}
        </>
     );
}
 
export default ChildrenComponent;