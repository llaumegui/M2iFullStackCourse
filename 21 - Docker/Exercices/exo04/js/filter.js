function filterSelection(c) {
	if (c == "all") {
		c = "";

		filter("separator", c);
	} else filter("separator", `first-${c}`, true);
	filter("project-cell", c);
}

function filter(className, c, hide = false) {
	var classes;
	classes = document.getElementsByClassName(className);
	var key = hide ? "hide" : "show";
	for (var i = 0; i < classes.length; i++) {
		removeClass(classes[i], "hide");
		removeClass(classes[i], "show");
		if (classes[i].className.indexOf(c) > -1) addClass(classes[i], key);
	}
}

function removeClass(element, name) {
	var arr1, arr2;
	arr1 = element.className.split(" ");
	arr2 = name.split(" ");
	for (var i = 0; i < arr2.length; i++) {
		while (arr1.indexOf(arr2[i]) > -1) {
			arr1.splice(arr1.indexOf(arr2[i]), 1);
		}
	}
	element.className = arr1.join(" ");
}

function addClass(element, name) {
	var arr1, arr2;
	arr1 = element.className.split(" ");
	arr2 = name.split(" ");

	for (var i = 0; i < arr2.length; i++) {
		if (arr1.indexOf(arr2[i]) == -1) {
			element.className += ` ${arr2[i]}`;
		}
	}
}
