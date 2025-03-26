function copyText(c) {
	navigator.clipboard.writeText(c);
}
function localize(language) {
	$("[lang]").each(function () {
		if ($(this).attr("lang").includes(language)) $(this).show();
		else $(this).hide();
	});
}

for (var j = 0; j < 2; j++) {
	if (j == 0)
		var btnContainer = document.getElementById("container-languages"); //languages
	
	else var btnContainer = document.getElementById("container-projects"); //projects

	var btns = btnContainer.getElementsByClassName("btn");
	for (var i = 0; i < btns.length; i++) {
		btns[i].addEventListener("click", function () {
			var parent = this.parentNode;
			var current = parent.getElementsByClassName("active");
			current[0].className = current[0].className.replace(" active", "");
			this.className += " active";
		});
	}
}

function toggleMode() {
	var element = document.body;
	element.classList.toggle("dark-mode");

	var icons = document.getElementsByClassName("icon");
	for(var i =0;i<icons.length;i++){
		icons[i].classList.toggle("filter-white");
	}
	
	var icons = document.getElementsByClassName("theme-icon");
	for(var i =0;i<icons.length;i++){
		icons[i].classList.toggle("hide");
	}

	var shapes = document.getElementsByClassName("top-rectangle");
		for (var i = 0; i < shapes.length; i++) {
			shapes[i].classList.toggle("rectDM");
		}

}
