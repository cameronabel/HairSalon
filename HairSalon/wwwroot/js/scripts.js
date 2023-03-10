function fetchClientDetails(){
  let clientId = document.getElementById('ClientId').value;
  fetch(`/Clients/GetClient/${clientId}`, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          }
        })
        .then(response => response.json())
        .then(response => {
          let client = JSON.parse(response);
          document.getElementById('client-stats').innerText = `${client.Name} - ${client.Phone} - ${client.Email}`;
        });
}

function fetchApplicableStylists(){
  let specialtyId = document.getElementById('SpecialtyId').value;
  fetch(`/Stylists/GetApplicableStylists/${specialtyId}`, {
          method: 'GET',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          }
        })
        .then(response => response.json())
        .then(response => {
          let stylists = JSON.parse(response);
          let stylistSelector = document.getElementById('StylistId');
          let size = stylistSelector.options.length;
          for (let i=1; i < size; i++){
            if (stylists.map(s => s.StylistId.toString()).includes(stylistSelector[i].value.toString())){
              
              stylistSelector[i].removeAttribute("disabled");
            } else {
              
              stylistSelector[i].setAttribute("disabled", "disabled");
            }
          }
        });
}


document.getElementById("showaddnewclient").addEventListener('click', e=> {
  document.getElementById('new-client-form').classList.remove('hidden');
  document.getElementById('showaddnewclient').classList.add('hidden');
  document.getElementById('hideaddnewclient').classList.remove('hidden');
  document.getElementById('select-service').classList.add('hidden');
  document.getElementById('select-stylist').classList.add('hidden');

  document.getElementById("ClientId").value=null;
  document.getElementById("SpecialtyId").value="";
  document.getElementById("StylistId").value="";
  document.getElementById("client-stats").innerText = "";
});
document.getElementById("hideaddnewclient").addEventListener('click', e=> {
  document.getElementById('new-client-form').classList.add('hidden');
  document.getElementById('showaddnewclient').classList.remove('hidden');
  document.getElementById('hideaddnewclient').classList.add('hidden');
});

document.getElementById("ClientId").addEventListener("change", e=> {
  if (e.target.value === null || e.target.value == ""){
    document.getElementById("select-service").classList.add("hidden");
    document.getElementById("select-stylist").classList.add("hidden");
    document.getElementById('client-stats').innerText = null;
  } else {
    document.getElementById("select-service").classList.remove("hidden");
    document.getElementById("hideaddnewclient").click();
    fetchClientDetails();
  }
});

document.getElementById("showaddnewservice").addEventListener('click', e=> {
  document.getElementById('new-service-form').classList.remove('hidden');
  document.getElementById('showaddnewservice').classList.add('hidden');
  document.getElementById('hideaddnewservice').classList.remove('hidden');
  document.getElementById("select-stylist").classList.add("hidden");

  document.getElementById("SpecialtyId").value="";
  document.getElementById("StylistId").value="";
});
document.getElementById('hideaddnewservice').addEventListener('click', e=> {
  document.getElementById('new-service-form').classList.add('hidden');
  document.getElementById('showaddnewservice').classList.remove('hidden');
  document.getElementById('hideaddnewservice').classList.add('hidden');
});

document.getElementById("SpecialtyId").addEventListener("change", e=> {
  if (e.target.value === null || e.target.value == ""){
    document.getElementById("select-stylist").classList.add("hidden");
  } else {
    document.getElementById("select-stylist").classList.remove("hidden");
    document.getElementById("hideaddnewservice").click();
  }
  fetchApplicableStylists();
});

document.getElementById("showaddnewstylist").addEventListener('click', e=> {
  document.getElementById('new-stylist-form').classList.remove('hidden');
  document.getElementById('showaddnewstylist').classList.add('hidden');
  document.getElementById('hideaddnewstylist').classList.remove('hidden');

  document.getElementById("StylistId").value="";
});
document.getElementById('hideaddnewstylist').addEventListener('click', e=> {
  document.getElementById('new-stylist-form').classList.add('hidden');
  document.getElementById('showaddnewstylist').classList.remove('hidden');
  document.getElementById('hideaddnewstylist').classList.add('hidden');
});

document.getElementById("StylistId").addEventListener("change", e=> {
  if (e.target.value === null || e.target.value == ""){
    document.getElementById("select-time").classList.add("hidden");
  } else {
    document.getElementById("select-time").classList.remove("hidden");
    document.getElementById("hideaddnewstylist").click();
  }
  fetchApplicableStylists();
});

if (document.getElementById("ClientId") != ""){
  let event = new Event('change');
  document.getElementById("ClientId").dispatchEvent(event);

  fetchClientDetails();
}