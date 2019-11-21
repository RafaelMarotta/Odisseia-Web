function changesidebar() {
    if ($(".sidebar").hasClass("sidebar")) {
        document.getElementById('sidebar').className = "Sidebar-mini";  
    }
    else {
        document.getElementById('sidebar').className = "sidebar"; 
    }
    
}
